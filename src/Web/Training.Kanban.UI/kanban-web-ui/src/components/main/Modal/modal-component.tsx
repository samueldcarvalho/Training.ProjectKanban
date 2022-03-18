

const UIModal = (props: any) => {
    return (
        <div className="kb-modal-overlay">
            <div className="kb-modal container">
                {props.children}
            </div>
        </div>
    );
}

export default UIModal;
