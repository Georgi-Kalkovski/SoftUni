function Search() {
    return (
        <div className="page-section banner-seo-check">
        <div className="wrap bg-image" style={{backgroundImage: 'url(../assets/img/bg_pattern.svg)'}}>
          <div className="container text-center">
            <div className="row justify-content-center wow fadeInUp">
              <div className="col-lg-8">
                <h2 className="mb-4">Check your Website SEO</h2>
                <form action="#">
                  <input type="text" className="form-control" placeholder="E.g google.com" />
                  <button type="submit" className="btn btn-success">Check Now</button>
                </form>
              </div>
            </div>
          </div> 
        </div> 
      </div> 
    );
}

export default Search;