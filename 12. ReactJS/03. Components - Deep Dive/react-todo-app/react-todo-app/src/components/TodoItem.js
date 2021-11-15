// import { useEffect } from 'react';
import './TodoItem.css';
 
export default function TodoItem({
    todo,
    onDelete,
    onClick,
}) {
    // useEffect(() => {
    //     console.log(`${id} - Mounted`);

    //     return () => {
    //         console.log(`${id} - Unmounted`);
    //     }
    // }, []);

    let listItemClasses = ['todo-item'];
    if (todo.isDone) {
        listItemClasses.push('todo-item-done');
    }

    return (
        <li onClick={() => onClick(todo.id)} className={listItemClasses.join(' ')} >
            {todo.text}
            <button onClick={(e) => onDelete(e, todo.id)}>x</button>
        </li>
    );
}