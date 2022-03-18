export type TitlePageProps = {
    title: string;
    description: string;
}

const TitlePageComponent = (props: TitlePageProps) => {
    return (
        <>
            <div className="kb-page-title">
                <p>{props.description.toUpperCase()}</p>
                <h3>{props.title}</h3>
            </div>
        </>
    )
}

export default TitlePageComponent;
