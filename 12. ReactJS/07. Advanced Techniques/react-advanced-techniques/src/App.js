import { Routes, Route } from 'react-router-dom';

import { AuthProvider } from './contexts/AuthContext';
import ErrorBondary from './ErrorBoundary';

import Login from './components/Login';
import Header from './components/Header';
import MyList from './components/MyList';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';

function App() {
  return (
    <ErrorBondary>
      <AuthProvider>
        <div className="site-wrapper">
          <Header />

          <Routes>
            <Route path="/login" element={<Login />} />
            <Route path="/dogs" element={<MyList />} />
          </Routes>
        </div>
      </AuthProvider>
    </ErrorBondary>
  );
}

export default App;
