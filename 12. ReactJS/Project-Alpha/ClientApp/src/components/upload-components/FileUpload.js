import React, { useState, useRef } from 'react';
import axios from 'axios';

const toBase64 = file => new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result);
    reader.onerror = error => reject(error);
});

const FileUpload = () => {

    const fileInputRef = useRef(null);

    const onSubmit = async () => {
        const file = fileInputRef.current.files[0];
        const base64 = await toBase64(file);
        await axios.post('/api/bookupload/upload', {base64File: base64, name: file.name});
        //window.location = `/books/viewbook?name=${file.name}`;
        //window.location = '/books/getcsv';
    };

    return (
        <div className="container">
            <div className="row mt-5">
                <div className="col-md-6">
                    <input ref={fileInputRef} type="file" className="form-control" />
                </div>
                <div className="col-md-6">
                    <button className='btn btn-primary btn-block' onClick={onSubmit}>Submit</button>
                </div>
            </div>
        </div>
    );
};

export default FileUpload;