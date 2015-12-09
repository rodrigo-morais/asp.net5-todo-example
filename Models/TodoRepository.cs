using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Todo.Models
{
	public class TodoRepository : ITodoRepository {
		static ConcurrentDictionary<string, TodoItem> todos = new ConcurrentDictionary<string, TodoItem>();
		
		public TodoRepository() {
			Add(new TodoItem { Name= "Item 1"});
		}
		
		public IEnumerable<TodoItem> GetAll() {
			return todos.Values;	
		}
		
		public void Add(TodoItem item) {
			item.Key = Guid.NewGuid().ToString();
			todos[item.Key] = item;
		}
		
		public TodoItem Find(string key) {
			TodoItem item;
			
			todos.TryGetValue(key, out item);
			return item;
		}
		
		public TodoItem Remove(string key) {
			var item = Find(key);
			
			todos.TryRemove(key, out item);
			
			return item;	
		}
		
		public void Update(TodoItem item) {
			todos[item.Key] = item;
		}
	}
}