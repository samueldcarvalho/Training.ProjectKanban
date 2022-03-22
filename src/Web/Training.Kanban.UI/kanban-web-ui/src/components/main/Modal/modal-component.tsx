import CardTitleComponent from "../titlecard-component";

const UIModal = (props: any) => {
    return (
        <div className="kb-modal-overlay">
            <div className="kb-modal kb-card container">
                <div className="kb-modal-header">
                    <CardTitleComponent title={props.title} description={props.description} align="center" />
                </div>

                <div className="kb-modal-body">
                    {props.children}
                </div>
            </div>
        </div>
    );
}

export default UIModal;
