﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoListApplication.Data;
using TodoListApplication.Dtos;
using TodoListApplication.Models;

namespace TodoListApplication.Controllers
{
    public class TodoController : Controller
    {
        private DataContext _context;

        public TodoController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Todo> todos =
                _context.Todos //This is required to load child objects
                .ToList();

            return View(todos);
        }

        public IActionResult Add()
        {
            var createTodo = new CreateTodo()
            {
                Todo = new Todo(),
                AllCategories = _context.Categories.ToList(),
            };
            return View(createTodo);
        }

        [HttpPost]
        public IActionResult Add(CreateTodo createTodo)
        {
            if (!ModelState.IsValid)
            {
                createTodo.AllCategories = _context.Categories.ToList();
                return View(createTodo);
            }

            _context.Todos.Add(createTodo.Todo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var todo = _context.Todos.Find(id);
            _context.Todos.Remove(todo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var todo = _context.Todos.Find(id);
            return View(todo);
        }

        [HttpPost]
        public IActionResult Update(Todo todo)
        {
            _context.Todos.Update(todo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}