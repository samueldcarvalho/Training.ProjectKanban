type CardTitleProps = {
    title: string;
    description: string;
    align: "flex-start" | "center" | "flex-end"
}

const CardTitleComponent = (props: CardTitleProps) => {
    return (
        <div className="kb-card-title" style={{ alignItems: props.align.toString() }}>
            <p>{props.title}</p>
            <p>{props.description}</p>
        </div>
    )
}

export default CardTitleComponent;
