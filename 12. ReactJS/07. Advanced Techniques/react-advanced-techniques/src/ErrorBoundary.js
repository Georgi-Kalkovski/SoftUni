import { Component } from 'react';

export default class ErrorBondary extends Component {
    constructor(props) {
        super(props);

        this.state = {
            error: null
        }
    }

    static getDerivedStateFromError(error) {
        console.log('getDerivedStateFromError');
        
        console.log(error);

        return { error };
    }
    
    componentDidCatch(error) {
        console.log('componentDidCatch');
    }

    render() {
        return this.state.error 
            ? <h1>404</h1>
            : this.props.children;
    }
}