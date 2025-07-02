import Task from "./Task";

/**
 * TaskList component displays a list of tasks.
 *
 * @param {Object} param0 - The props object.
 * @param {Array} param0.tasks - The array of task objects to display.
 * @param {Function} param0.onTaskSelect - The function to call when a task is selected.
 * @returns {JSX.Element} The rendered task list component.
 */
function TaskList({ tasks, onTaskSelect }) {
  if (!tasks) return <div>No tasks available</div>;
  return (
    <div className="flex flex-wrap gap-4 p-4 justify-between">
      {tasks.map((task) => (
        <Task key={task.Id ?? task.id} task={task} onClick={() => onTaskSelect(task)} />
      ))}
    </div>
  );
}

export default TaskList;
