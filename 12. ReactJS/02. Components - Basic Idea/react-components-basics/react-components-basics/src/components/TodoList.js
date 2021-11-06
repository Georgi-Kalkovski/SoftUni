import { useState } from 'react';
import TodoListItem from './TodoListItem';

function TodoList() {
    let [count, setCount] = useState(0);
    let [name, setName] = useState('');

    console.log('render');

    const addButtonClickHandler = () => {
        setCount(count + 1);
    };

    const inputChangeHandler = (e) => {
        setName(e.target.value);
    };

    const peshoHeader = (
        <header>
            <h3>He is the best!</h3>
            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Minus, consectetur!</p>
        </header>
    );

    return (
        <>
            { name && <h2>Counter - {name}</h2> }

            { name || <h2> No name </h2> }

            {name == 'Pesho'
                ? peshoHeader
                : <h3>Nah</h3> 
            }

            <ul>
                <TodoListItem>{count}</TodoListItem>
            </ul>

            <input type="text" onBlur={inputChangeHandler} />

            <button onClick={addButtonClickHandler}>+</button>
        </>
    );
}

export default TodoList;
