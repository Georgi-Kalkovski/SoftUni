// Importing the components Header.js, Footer.js, Main.js
import Header from './components/Header';
import Footer from './components/Footer.js';
import Main from './components/Main.js';

import './App.css';

function App() {
  return (
    <div className="App">
      {/* <Header></Header> or <Header /> */}
      <Header />
      <Main />
      <Footer />
    </div>
  );
}

export default App;
