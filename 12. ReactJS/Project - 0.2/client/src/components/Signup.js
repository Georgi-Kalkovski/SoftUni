import React, { useState } from 'react';
const axios = require('axios');
const FormData = require('form-data');

export default function Signup() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const submitChangeHanfler = (e) => {
        e.preventDefault();
        console.log(e.target[0].value);
        console.log(e.target[1].value);
        setEmail(e.target[0].value);
        setPassword(e.target[1].value);
    };

    
    async function makeGetRequest() {
        const form_data = new FormData();
        form_data.append('email', email);
        form_data.append('password', password);
    
        axios.post('http://localhost:4000/app/signup')
        .then(response => console.log(response.form_data));
    }
    
    makeGetRequest();

    return (
        <>
            <div className="container">
                <div className="form-div">
                    <form onSubmit={submitChangeHanfler} >
                        <input type="text"
                            placeholder="E-mail"
                            className="form-control form-group"
                            onChange={e => setEmail(e.target.value)}
                            value={email} />

                        <input type="password"
                            placeholder="Password"
                            className="form-control form-group"
                            onChange={e => setPassword(e.target.value)}
                            value={password} />

                        <input type="submit"
                            className="btn btn-danger btn-block"
                            value="Submit"
                        />
                    </form>
                </div>
            </div>
        </>
    );
};