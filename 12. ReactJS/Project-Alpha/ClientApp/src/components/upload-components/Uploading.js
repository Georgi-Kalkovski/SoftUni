import React, { useState,useEffect, useRef } from 'react';

const Uploading = () => { 
    const [textboxValue, setTextboxValue] = useState('');
    const countRef = useRef(0);
    const textbox2Ref = useRef(null);

    useEffect(() => {
       countRef.current++;
    });

    return (
        <div className="container" style={{border: '1px solid #008080'}} >
            <input type="text" value={textboxValue} onChange={e => setTextboxValue(e.target.value)} placeholder="Text 1" />
            <br />
            <input ref={textbox2Ref} type="text" placeholder="Text 2" />
            <h1>The value is {textboxValue}</h1>
            <h2>{countRef.current}</h2>
            <button className='btn btn-primary' onClick={() => textbox2Ref.current.focus()}>Focus textbox 2</button>
        </div>
    );
};

export default Uploading;