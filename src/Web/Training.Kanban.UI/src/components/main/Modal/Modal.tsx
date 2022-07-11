import CardTitleComponent from "../titlecard-component";
import { MdOutlineClose } from "react-icons/md"
import styles from "./modal.module.css"

const Modal = (props: any) => {
    return (
        <div className={styles.kb_modal_overlay}>
            <div className={styles.kb_modal + " kb-card col-10 col-sm-8 col-lg-6"}>
                <div className={styles.kb_modal_header}>
                    <CardTitleComponent title={props.title} description={props.description} align="center" />
                    <button className={styles.kb_modal_close_button} onClick={() => props.onCloseHandler()}>
                        <MdOutlineClose />
                    </button>
                </div>

                <div className={styles.kb_modal_body}>
                    {props.children}
                </div>
            </div>
        </div>
    );
}

export default Modal;
