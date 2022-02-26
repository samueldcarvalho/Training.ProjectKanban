export default function NavbarComponent() {
    return (
        <>
            <header className="db-mainbar">
                <div className="container">
                    <div className="col">
                        <p>Kanban</p>
                    </div>
                </div>
            </header>
            <header className="db-mainbar db-navbar">
                <div className="container db-navbar-options">
                    <div className="col">
                        <a className="db-navbar-button" href="">Home</a>
                        <a className="db-navbar-button" href="">Boards</a>
                        <a className="db-navbar-button" href="">Teams</a>
                    </div>

                    <div className="col db-navbar-end">
                        <a className="db-navbar-button-taskpoints" href="">Look for Taskpoints!</a>
                        <p>329</p>
                    </div>
                </div>
            </header>
        </>
    )
}
