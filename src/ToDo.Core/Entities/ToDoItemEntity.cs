namespace ToDo.Core.Entities {
    public class ToDoItemEntity {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Title { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public string Status { get; private set; } = "toDo";
        public string Priority { get; private set; } = "postponable";
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? DeadlineAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }

        protected ToDoItemEntity() { }

        public ToDoItemEntity(
            string title,
            string? description = null,
            string status = "toDo",
            string priority = "postponable",
            DateTime? deadlineAt = null,
            DateTime? completedAt = null) {
            UpdateTitle(title);
            Description = description;
            Priority = priority;
            DeadlineAt = deadlineAt;
            SetStatus(status, completedAt);
        }

        public void UpdateTitle(string newTitle) {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("O título não pode ser vazio.");

            Title = newTitle;
        }

        public void SetStatus(string newStatus, DateTime? customCompletedAt = null) {
            Status = newStatus;

            if (newStatus == "completed") {
                CompletedAt = customCompletedAt ?? DateTime.UtcNow;
            } else {
                CompletedAt = null;
            }
        }

        public void UpdateDetails(
            string title,
            string? description,
            string status,
            string priority,
            DateTime? deadlineAt,
            DateTime? completedAt) {
            UpdateTitle(title);
            Description = description;
            Priority = priority;
            DeadlineAt = deadlineAt;
            SetStatus(status, completedAt);
        }
    }
}