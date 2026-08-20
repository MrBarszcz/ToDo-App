using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Core.Entities {
    public class ToDoItemEntity {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Title { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public string? Status { get; set; }
        public string? Priotity { get; private set; }
        public bool IsCompleted { get; private set; } = false;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? DeadlineAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }

        public ToDoItemEntity(string title, string? description = null, DateTime? deadlineAt = null) {
            Title = title;
            Description = description;
            DeadlineAt = deadlineAt;
        }

        public void MarkAsCompleted() {
            if (IsCompleted) return;

            IsCompleted = true;
            CompletedAt = DateTime.UtcNow;
        }

        public void Reopen() {
            if (!IsCompleted) return;

            IsCompleted = false;
            CompletedAt = null;
        }

        public void UpdateTitle(string newTitle) {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("O título não pode ser vazio");

            Title = newTitle;
        }
    }
}