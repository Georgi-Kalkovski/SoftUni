export default function ServiceCard({
    imageUrl,
    title,
    description,
}) {
    return (
        <div className="col-lg-4">
            <div className="card-service wow fadeInUp">
                <div className="header">
                    <img src={imageUrl} alt="" />
                </div>
                <div className="body">
                    <h5 className="text-secondary">{title}</h5>
                    <p>{description}</p>
                    <a href="service.html" className="btn btn-primary">Read More</a>
                </div>
            </div>
        </div>
    );
}