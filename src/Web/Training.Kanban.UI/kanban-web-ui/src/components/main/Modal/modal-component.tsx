import CardTitleComponent from "../titlecard-component";
import { MdOutlineClose } from "react-icons/md"

const UIModal = (props: any) => {
    return (
        <div className="kb-modal-overlay">
            <div className="kb-modal kb-card col-10 col-sm-8 col-lg-6">
                <div className="kb-modal-header">
                    <CardTitleComponent title={props.title} description={props.description} align="center" />
                    <button className="kb-modal-close-button" onClick={() => props.onCloseHandler()}>
                        <MdOutlineClose />
                    </button>
                </div>

                <div className="kb-modal-body">
                    {props.children}
                </div>
            </div>
        </div>
    );
}

export default UIModal;
