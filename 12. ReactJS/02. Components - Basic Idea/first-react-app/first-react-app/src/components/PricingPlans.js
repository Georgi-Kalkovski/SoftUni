export default function PricingPlans() {
    return (
        <div className="page-section">
            <div className="container">
                <div className="text-center wow fadeInUp">
                    <div className="subhead">Pricing Plan</div>
                    <h2 className="title-section">Choose plan the right for you</h2>
                    <div className="divider mx-auto"></div>
                </div>
                <div className="row mt-5">
                    <div className="col-lg-4 py-3 wow zoomIn">
                        <div className="card-pricing">
                            <div className="header">
                                <div className="pricing-type">Basic</div>
                                <div className="price">
                                    <span className="dollar">$</span>
                                    <h1>39<span className="suffix">.99</span></h1>
                                </div>
                                <h5>Per Month</h5>
                            </div>
                            <div className="body">
                                <p>25 Analytics <span className="suffix">Campaign</span></p>
                                <p>1,300 Change <span className="suffix">Keywords</span></p>
                                <p>Social Media <span className="suffix">Reviews</span></p>
                                <p>1 Free <span className="suffix">Optimization</span></p>
                                <p>24/7 <span className="suffix">Support</span></p>
                            </div>
                            <div className="footer">
                                <a href="#" className="btn btn-pricing btn-block">Subscribe</a>
                            </div>
                        </div>
                    </div>

                    <div className="col-lg-4 py-3 wow zoomIn">
                        <div className="card-pricing marked">
                            <div className="header">
                                <div className="pricing-type">Standar</div>
                                <div className="price">
                                    <span className="dollar">$</span>
                                    <h1>59<span className="suffix">.99</span></h1>
                                </div>
                                <h5>Per Month</h5>
                            </div>
                            <div className="body">
                                <p>25 Analytics <span className="suffix">Campaign</span></p>
                                <p>1,300 Change <span className="suffix">Keywords</span></p>
                                <p>Social Media <span className="suffix">Reviews</span></p>
                                <p>1 Free <span className="suffix">Optimization</span></p>
                                <p>24/7 <span className="suffix">Support</span></p>
                            </div>
                            <div className="footer">
                                <a href="#" className="btn btn-pricing btn-block">Subscribe</a>
                            </div>
                        </div>
                    </div>

                    <div className="col-lg-4 py-3 wow zoomIn">
                        <div className="card-pricing">
                            <div className="header">
                                <div className="pricing-type">Professional</div>
                                <div className="price">
                                    <span className="dollar">$</span>
                                    <h1>99<span className="suffix">.99</span></h1>
                                </div>
                                <h5>Per Month</h5>
                            </div>
                            <div className="body">
                                <p>25 Analytics <span className="suffix">Campaign</span></p>
                                <p>1,300 Change <span className="suffix">Keywords</span></p>
                                <p>Social Media <span className="suffix">Reviews</span></p>
                                <p>1 Free <span className="suffix">Optimization</span></p>
                                <p>24/7 <span className="suffix">Support</span></p>
                            </div>
                            <div className="footer">
                                <a href="#" className="btn btn-pricing btn-block">Subscribe</a>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    )
}