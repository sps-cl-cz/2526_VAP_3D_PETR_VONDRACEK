using ProjectManager.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Database
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath = "projects1.db3")
        {
            _database = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, dbPath));
            _database.CreateTableAsync<Project>().Wait();
        }

        public List<Project> GetProjects()
        {
            var task = GetProjectsAsync();
            task.Wait();
            return task.Result;
        }

        public Task<List<Project>> GetProjectsAsync()
        {
            return _database.Table<Project>().ToListAsync();
        }

        public Task<int> SaveProjectAsync(Project project)
        {
            if (project.Id != 0)
                return _database.UpdateAsync(project);
            else
                return _database.InsertAsync(project);
        }

        public Task<int> DeleteProjectAsync(Project project)
        {
            return _database.DeleteAsync(project);
        }

        public Task<int> DeleteAllProjectsAsync()
        {
            return _database.DeleteAllAsync<Project>();
        }
    }
}
