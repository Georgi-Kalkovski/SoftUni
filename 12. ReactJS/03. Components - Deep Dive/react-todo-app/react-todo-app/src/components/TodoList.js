import { useState, useEffect } from 'react';
import uniqid from 'uniqid';
import TodoItem from './TodoItem';
import { createTodo } from '../services/todoService';

const API_URL = 'http://localhost:3030/jsonstore';

export default function TodoList() {
    const [todos, setTodos] = useState([]);

    useEffect(() => {
        fetch(`${API_URL}/todos`)
            .then(res => res.json())
            .then(todosResult => {
                setTodos(Object.values(todosResult));
            });
    }, []);

    const onTodoInputBlur = (e) => {
        let todo = {
            id: uniqid(),
            text: e.target.value,
            isDone: false,
        };

        createTodo(todo)
            .then(createdTodo => {
                setTodos(oldTodos => [
                    ...oldTodos,
                    createdTodo
                ]);

                e.target.value = '';
            })
            .catch(err => {
                console.log(err);
            });
    };

    const deleteTodoItemClickHandler = (e, id) => {
        e.stopPropagation();
        setTodos(oldTodos => oldTodos.filter(todo => todo.id !== id));
    };

    const toggleTodoItemClickHandler = (id) => {
        setTodos(oldTodos => {
            // let selectedTodo = oldTodos.find(x => x.id === id);
            // let selectedIndex = oldTodos.findIndex(x => x.id === id);
            // let toggledTodo = { ...selectedTodo, isDone: !selectedTodo.isDone };

            // return [
            //     ...oldTodos.slice(0, selectedIndex),
            //     toggledTodo,
            //     ...oldTodos.slice(selectedIndex + 1),
            // ];

            return oldTodos.map(todo => 
                todo.id === id 
                    ? {...todo, isDone: !todo.isDone} 
                    : todo
            );
        });
    };

    return (
        <>
            <label htmlFor="todo-name">Add Todo</label>
            <input type="text" id="todo-name" onBlur={onTodoInputBlur} name="todo" />
            <ul>
                {todos.map(todo =>
                    <TodoItem
                        key={todo.id}
                        todo={todo}
                        onDelete={deleteTodoItemClickHandler}
                        onClick={toggleTodoItemClickHandler}
                    />
                )}
            </ul>
        </>
    );
};