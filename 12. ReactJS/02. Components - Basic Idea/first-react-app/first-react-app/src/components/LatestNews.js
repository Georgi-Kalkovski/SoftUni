export default function LatestNews() {
    return (
        <div className="page-section">
        <div className="container">
          <div className="text-center wow fadeInUp">
            <div className="subhead">Our Blog</div>
            <h2 className="title-section">Read Latest News</h2>
            <div className="divider mx-auto"></div>
          </div>
    
          <div className="row mt-5">
            <div className="col-lg-4 py-3 wow fadeInUp">
              <div className="card-blog">
                <div className="header">
                  <div className="post-thumb">
                    <img src="../assets/img/blog/blog-1.jpg" alt=""/>
                  </div>
                </div>
                <div className="body">
                  <h5 className="post-title"><a href="#">Source of Content Inspiration</a></h5>
                  <div className="post-date">Posted on <a href="#">27 Jan 2020</a></div>
                </div>
              </div>
            </div>
            
            <div className="col-lg-4 py-3 wow fadeInUp">
              <div className="card-blog">
                <div className="header">
                  <div className="post-thumb">
                    <img src="../assets/img/blog/blog-2.jpg" alt=""/>
                  </div>
                </div>
                <div className="body">
                  <h5 className="post-title"><a href="#">Source of Content Inspiration</a></h5>
                  <div className="post-date">Posted on <a href="#">27 Jan 2020</a></div>
                </div>
              </div>
            </div>
    
            <div className="col-lg-4 py-3 wow fadeInUp">
              <div className="card-blog">
                <div className="header">
                  <div className="post-thumb">
                    <img src="../assets/img/blog/blog-3.jpg" alt=""/>
                  </div>
                </div>
                <div className="body">
                  <h5 className="post-title"><a href="#">Source of Content Inspiration</a></h5>
                  <div className="post-date">Posted on <a href="#">27 Jan 2020</a></div>
                </div>
              </div>
            </div>
    
            <div className="col-12 mt-4 text-center wow fadeInUp">
              <a href="blog.html" className="btn btn-primary">View More</a>
            </div>
          </div>
        </div>
      </div>
    )
}