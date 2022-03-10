type CardTitleProps = {
    title: string;
    description: string;
}

const CardTitleComponent = (props: CardTitleProps) => {
    return (
        <div className="kb-card-title">
            <p>{props.title}</p>
            <p>{props.description}</p>
        </div>
    )
}

export default CardTitleComponent;
