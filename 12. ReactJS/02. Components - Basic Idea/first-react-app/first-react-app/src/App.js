import Footer from './components/Footer';
import Header from './components/Header';
import TopServices from './components/TopServices';
import AboutUs from './components/AboutUs';
import OurServices from './components/OurServices';
import Search from './components/Search';
import PricingPlans from './components/PricingPlans';
import Mission from './components/Mission';
import LatestNews from './components/LatestNews';

function App() {
    return (
        <div>
            <div className="back-to-top"></div>

            <Header />

            <TopServices />

            <AboutUs />

            <OurServices />

            <Search />

            <PricingPlans />

            <Mission />

            <LatestNews />

            <Footer />
        </div>
    );
}

export default App;
