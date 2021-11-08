import React, { Component } from 'react';
import FileUpload from './upload-components/FileUpload';
import Uploading from './upload-components/Uploading';

export class Upload extends Component {
  static displayName = Upload.name;

  render () {
    return (
        <FileUpload />
    );
  }
}