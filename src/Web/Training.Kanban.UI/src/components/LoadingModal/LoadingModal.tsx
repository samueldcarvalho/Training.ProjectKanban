import ModalGeneric from "../ModalGeneric/ModalGeneric";
import LoaderSpinning from "../LoadingSpinner/LoaderSpinning";
import styles from "./LoadingModal.module.css";

type LoadingModalProps = {
  isLoading: boolean;
  loadingText: string;
};

const LoadingModal = ({ isLoading, loadingText }: LoadingModalProps) => {
  return isLoading == true ? (
    <ModalGeneric>
      <div>
        <div className={styles.loadingContainer + " kb-card"}>
          <LoaderSpinning />
          <div className={styles.loadingTextContainer}>
            <p>{loadingText}</p>
          </div>
        </div>
      </div>
    </ModalGeneric>
  ) : (
    <></>
  );
};

export default LoadingModal;
