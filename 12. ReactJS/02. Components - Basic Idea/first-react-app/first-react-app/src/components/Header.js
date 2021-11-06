export default function Header() {
    return (
        <header>
            <nav className="navbar navbar-expand-lg navbar-light bg-white sticky" data-offset="500">
                <div className="container">
                    <a href="#" className="navbar-brand">Seo<span className="text-primary">Gram.</span></a>

                    <button className="navbar-toggler" data-toggle="collapse" data-target="#navbarContent" aria-controls="navbarContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>

                    <div className="navbar-collapse collapse" id="navbarContent">
                        <ul className="navbar-nav ml-auto">
                            <li className="nav-item active">
                                <a className="nav-link" href="index.html">Home</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="about.html">About</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="service.html">Services</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="blog.html">Blog</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="contact.html">Contact</a>
                            </li>
                            <li className="nav-item">
                                <a className="btn btn-primary ml-lg-2" href="#">Free Analytics</a>
                            </li>
                        </ul>
                    </div>

                </div>
            </nav>

            <div className="container">
                <div className="page-banner home-banner">
                    <div className="row align-items-center flex-wrap-reverse h-100">
                        <div className="col-md-6 py-5 wow fadeInLeft">
                            <h1 className="mb-4">Let's Check and Optimize your website!</h1>
                            <p className="text-lg text-grey mb-5">Ignite the most powerfull growth engine you have ever built for your company</p>
                            <a href="#" className="btn btn-primary btn-split">Watch Video <div className="fab"><span className="mai-play"></span></div></a>
                        </div>
                        <div className="col-md-6 py-5 wow zoomIn">
                            <div className="img-fluid text-center">
                                <img src="/img/banner_image_1.svg" alt="" />
                            </div>
                        </div>
                    </div>
                    <a href="#about" className="btn-scroll" data-role="smoothscroll"><span className="mai-arrow-down"></span></a>
                </div>
            </div>
        </header>
    );
}