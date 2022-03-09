const Wrapper = (props: any) => {
    return (
        <>
            <div className="kb-main-header">
                <div className="container">
                    <div className="row">
                        <div className="col">
                            <div className="kb-main-header-options">
                                <div className="kb-main-header-logo">
                                    <h1>Kanban</h1>
                                </div>
                                <div className="kb-main-header-end">
                                    teste
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className="kb-submenu-header">
                <div className="container">
                    <div className="row">
                        <div className="col">
                            <div className="kb-submenu-header-buttons">
                                <label htmlFor="menu-button">
                                    <a id="menu-button">Home</a>
                                </label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className="container">
                <div className="row">
                    <div className="col">
                        {props.children}
                    </div>
                </div>
            </div>
        </>
    )
}

export default Wrapper;
