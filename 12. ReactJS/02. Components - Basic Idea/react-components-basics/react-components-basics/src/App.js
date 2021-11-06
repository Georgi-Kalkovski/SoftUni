import TodoList from './components/TodoList';
import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>ToDo App</h1>
      </header>

      <main>
        <TodoList />
      </main>

      <footer>
        <p>All rights reserved &copy;</p>
      </footer>
    </div>
  );
}

export default App;
