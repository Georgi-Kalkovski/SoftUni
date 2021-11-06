function Footer() {
    return (
        <footer className="page-footer bg-image" style={{ backgroundImage: 'url(../assets/img/world_pattern.svg)' }}>
            <div className="container">
                <div className="row mb-5">
                    <div className="col-lg-3 py-3">
                        <h3>SEOGram</h3>
                        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Libero amet, repellendus eius blanditiis in iusto eligendi iure.</p>

                        <div className="social-media-button">
                            <a href="#"><span className="mai-logo-facebook-f"></span></a>
                            <a href="#"><span className="mai-logo-twitter"></span></a>
                            <a href="#"><span className="mai-logo-google-plus-g"></span></a>
                            <a href="#"><span className="mai-logo-instagram"></span></a>
                            <a href="#"><span className="mai-logo-youtube"></span></a>
                        </div>
                    </div>
                    <div className="col-lg-3 py-3">
                        <h5>Company</h5>
                        <ul className="footer-menu">
                            <li><a href="#">About Us</a></li>
                            <li><a href="#">Career</a></li>
                            <li><a href="#">Advertise</a></li>
                            <li><a href="#">Terms of Service</a></li>
                            <li><a href="#">Help & Support</a></li>
                        </ul>
                    </div>
                    <div className="col-lg-3 py-3">
                        <h5>Contact Us</h5>
                        <p>203 Fake St. Mountain View, San Francisco, California, USA</p>
                        <a href="#" className="footer-link">+00 1122 3344 5566</a>
                        <a href="#" className="footer-link">seogram@temporary.com</a>
                    </div>
                    <div className="col-lg-3 py-3">
                        <h5>Newsletter</h5>
                        <p>Get updates, news or events on your mail.</p>
                        <form action="#">
                            <input type="text" className="form-control" placeholder="Enter your email.." />
                            <button type="submit" className="btn btn-success btn-block mt-2">Subscribe</button>
                        </form>
                    </div>
                </div>

                <p className="text-center" id="copyright">Copyright &copy; 2020. This template design and develop by <a href="https://macodeid.com/" target="_blank">MACode ID</a></p>
            </div>
        </footer>
    );
}

export default Footer;