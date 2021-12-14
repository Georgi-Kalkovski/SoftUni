import { createContext, useContext, useState, useReducer } from 'react';

export const AuthContext = createContext();

const initialState = {
    _id: '',
    email: '',
};

const reducer = (state, action) => {
    switch (action.type) {
        case 'LOGIN':
            return { ...state, email: action.payload }
        case 'LOGOUT':
            return initialState;
        default:
            return state;
    }
};

export const AuthProvider = ({
    children
}) => {
    // const [user, setUser] = useState(initialState);
    const [user, dispatch] = useReducer(reducer, initialState);

    const login = (email, password) => {
        // setUser({
        //     email,
        // });

        dispatch({
            type: 'LOGIN',
            payload: email
        });
    };

    const logout = () => dispatch({type: 'LOGOUT'});

    return (
        <AuthContext.Provider value={{ user, login, logout, isAuthenticated: Boolean(user.email) }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => {
    const authState = useContext(AuthContext);

    return authState;
}