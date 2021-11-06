import ServiceCard from './ServiceCard';

export default function TopServices() {
    return (
        <div className="page-section">
            <div className="container">
                <div className="row">
                    <ServiceCard
                        title="SEO Consultancy"
                        description="We help you define your SEO objective & develop a realistic strategy with you"
                        imageUrl="../assets/img/services/service-1.svg"
                    />

                    <ServiceCard
                        title="Content Marketing"
                        description="We help you define your SEO objective & develop a realistic strategy with you"
                        imageUrl="../assets/img/services/service-2.svg"
                    />

                    <ServiceCard
                        title="Keyword Research"
                        description="We help you define your SEO objective & develop a realistic strategy with you"
                        imageUrl="../assets/img/services/service-3.svg"
                    />
                </div>
            </div>
        </div>
    )
}