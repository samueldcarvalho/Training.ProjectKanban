import Link from "next/link";
import TitlePageComponent, { TitlePageProps } from "./titlepage-component";

const Wrapper = (props: any) => {
    return (
        <>
           
            <div className="kb-submenu-header">
                <div className="container">
                    <div className="row">
                        <div className="col">
                            <h1>Kanban</h1>
                        </div>
                        <div className="col">
                            <div className="kb-submenu-header-buttons">
                                <Link href="/">
                                    <label htmlFor="menu-button">
                                        <a id="menu-button">Home</a>
                                    </label>
                                </Link>
                                <Link href="/teams">
                                    <label htmlFor="menu-button">
                                        <a id="menu-button">Teams</a>
                                    </label>
                                </Link>
                                <Link href="/boards">
                                    <label htmlFor="menu-button">
                                        <a id="menu-button">Boards</a>
                                    </label>
                                </Link>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className="container">
                <div className="row">
                    <div className="col kb-body">
                        <TitlePageComponent title={props.titlePagePops.title} description={props.titlePagePops.description} />
                        {props.children}
                    </div>
                </div>
            </div>
        </>
    )
}

export default Wrapper;
