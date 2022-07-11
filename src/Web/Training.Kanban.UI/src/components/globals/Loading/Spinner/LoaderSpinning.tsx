import styles from "./LoaderSpinning.module.css";

const LoaderSpinning = () => {
  return (
    <div className={styles.LoaderContainer}>
      <div className={styles.LoaderSpinner}></div>
    </div>
  );
};

export default LoaderSpinning;
