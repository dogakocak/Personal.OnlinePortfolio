import dogaLogo from '../assets/doga_logo.jpg';

import './HomePage.css';

export const HomePage = () => {
    return (
        <div className="HomePage">
            <img src={dogaLogo} alt="WebSite Logo" />
            <h1 className="title">Hello world!</h1>
            <p className="description">Welcome to my personal website, where I showcase my projects and skills.</p>

            <div className="box">
                <h2>.NET Developer</h2>
            </div>
        </div>
    );
};
