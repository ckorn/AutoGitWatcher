using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoGitWatcher
{
    public class AutoGitWatcher
    {
        private readonly List<FileSystemWatcher> fileSystemWatcherList = new();
        private readonly Dictionary<FileSystemWatcher, DateTime> fileSystemWatcherLastChangeDictionary = new ();
        private Task? gitPushTask = null;
        private Task? gitPullTask = null;

        public event EventHandler<string>? Log;

        public void StartWatch(string[] directoryArray) 
        {
            StopWatch();
            foreach (string directory in directoryArray)
            {
                FileSystemWatcher fileSystemWatcher = new(directory)
                {
                    IncludeSubdirectories = true
                };
                fileSystemWatcher.Changed += FileSystemWatcher_Changed;
                fileSystemWatcher.Created += FileSystemWatcher_Created;
                fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;
                fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
                fileSystemWatcher.Error += FileSystemWatcher_Error;
                fileSystemWatcher.EnableRaisingEvents = true;
                fileSystemWatcherList.Add(fileSystemWatcher);
            }
            if (gitPushTask == null)
            {
                gitPushTask = Task.Factory.StartNew(() => GitPushTaskRun());
            }
            Log?.Invoke(this, $"Start watching {directoryArray.Length} directories");
        }

        public void StartPull(string[] directoryArray)
        {
            if (gitPullTask != null)
            {
                throw new InvalidOperationException();
            }
            gitPullTask = Task.Factory.StartNew((x) => GitPullTaskRun(x as List<string>), directoryArray.ToList());
        }

        private void StopWatch() 
        {
            foreach (FileSystemWatcher fileSystemWatcher in fileSystemWatcherList)
            {
                fileSystemWatcher.EnableRaisingEvents = false;
                fileSystemWatcher.Changed -= FileSystemWatcher_Changed;
                fileSystemWatcher.Created -= FileSystemWatcher_Created;
                fileSystemWatcher.Renamed -= FileSystemWatcher_Renamed;
                fileSystemWatcher.Deleted -= FileSystemWatcher_Deleted;
                fileSystemWatcher.Error -= FileSystemWatcher_Error;
            }
            fileSystemWatcherList.Clear();
            lock (fileSystemWatcherLastChangeDictionary)
            {
                fileSystemWatcherLastChangeDictionary.Clear();
            }
        }

        private void FileSystemWatcher_Error(object sender, ErrorEventArgs e)
        {
            throw e.GetException();
        }

        private void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            RecordChange((FileSystemWatcher)sender, e.FullPath);
        }

        private void FileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            RecordChange((FileSystemWatcher)sender, e.FullPath);
        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            RecordChange((FileSystemWatcher)sender, e.FullPath);
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            RecordChange((FileSystemWatcher)sender, e.FullPath);
        }

        private void RecordChange(FileSystemWatcher fileSystemWatcher, string path) 
        {
            // Ignore changes in the git repository because of the commit
            if (path.Contains(".git"))
            {
                return;
            }
            lock (fileSystemWatcherLastChangeDictionary)
            {
                fileSystemWatcherLastChangeDictionary[fileSystemWatcher] = DateTime.Now;
            }
        }

        private void GitPushTaskRun() 
        {
            while (true)
            {
                Thread.Sleep(1000);
                lock (fileSystemWatcherLastChangeDictionary)
                {
                    List<FileSystemWatcher> toDelete = new();
                    try
                    {
                        foreach (KeyValuePair<FileSystemWatcher, DateTime> keyValuePair in fileSystemWatcherLastChangeDictionary)
                        {
                            if (DateTime.Now - keyValuePair.Value > new TimeSpan(0, 0, 2))
                            {
                                toDelete.Add(keyValuePair.Key);
                                string directory = keyValuePair.Key.Path;
                                using Repository repository = new(directory);
                                Commands.Stage(repository, "*");
                                Signature signature = repository.Config.BuildSignature(DateTimeOffset.Now);
                                repository.Commit("AutoGitWatcher", signature, signature);
                                // pushing to ssh is not supported and the ssh lib is outdated.
                                using Process? process = Process.Start(new ProcessStartInfo() 
                                {
                                    WorkingDirectory = directory,
                                    FileName = "git",
                                    Arguments = "push",
                                    CreateNoWindow = true,
                                });
                                process?.WaitForExit();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        this.Log?.Invoke(this, GetExceptionText(e));
                    }
                    finally
                    {
                        toDelete.ForEach(x => fileSystemWatcherLastChangeDictionary.Remove(x));
                    }
                }
            }
        }

        private void GitPullTaskRun(List<string>? directoryList)
        {
            if (directoryList == null)
            {
                return;
            }
            while (true)
            {
                Thread.Sleep(5000);
                List<string> toDelete = new();
                try
                {
                    Parallel.ForEach(directoryList, (string directory) =>
                    {
                        string gitDirectory = Path.Combine(directory, ".git");
                        if (!Directory.Exists(gitDirectory))
                        {
                            this.Log?.Invoke(this, $"{directory} not a git repository");
                            lock (toDelete)
                            {
                                toDelete.Add(directory);
                            }
                            return;
                        }
                        using Repository repository = new(directory);
                        string beforeFetch = repository.Branches["origin/master"].Tip.Sha;
                        // fecthing from ssh is not supported and the ssh lib is outdated.
                        using Process? processFetch = Process.Start(new ProcessStartInfo()
                        {
                            WorkingDirectory = directory,
                            FileName = "git",
                            Arguments = "fetch",
                            CreateNoWindow = true,
                        });
                        processFetch?.WaitForExit();
                        string afterFetch = repository.Branches["origin/master"].Tip.Sha;
                        // pull makes sihost.exe consume 100% CPU. So workaround it by just pulling
                        // when we fetched something.
                        if (beforeFetch != afterFetch)
                        {
                            // pulling from ssh is not supported and the ssh lib is outdated.
                            using Process? processPull = Process.Start(new ProcessStartInfo()
                            {
                                WorkingDirectory = directory,
                                FileName = "git",
                                Arguments = "pull",
                                CreateNoWindow = true,
                            });
                            processPull?.WaitForExit();
                        }
                    });
                }
                catch (Exception e)
                {
                    this.Log?.Invoke(this, GetExceptionText(e));
                }
                finally
                {
                    toDelete.ForEach(x => directoryList.Remove(x));
                }
            }
        }

        private string GetExceptionText(Exception e) 
        {
            string text = e.Message;
            text += Environment.NewLine + e.StackTrace;
            if (e.InnerException != null)
            {
                text += Environment.NewLine + GetExceptionText(e.InnerException);
            }
            return text;
        }
    }
}
