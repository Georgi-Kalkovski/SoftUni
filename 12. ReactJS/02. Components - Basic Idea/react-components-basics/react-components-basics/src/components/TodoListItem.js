const TodoListItem = (props) => {
    let color = 'black';

    if (props.children > 0 && props.children <= 3) {
        color = 'red';
    } else if (props.children > 3) {
        color = 'green';
    }
 
    return <li style={{color}}>{props.children}</li>;
};

export default TodoListItem;