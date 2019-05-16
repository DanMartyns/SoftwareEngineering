import React, {Component} from 'react';
import Header from '../../components/Header/';
import Nav from '../../components/Nav/';
import Footer from '../../components/Footer/';
import Body from '../../components/Body/';



class Full extends Component {
    
    componentDidMount() {
        this.render();
    };

    render() {
        return (
            <html>         
                <div className="app">
                    <Header/>
                    <Nav />
                    <Body />
                    <Footer/>
                </div>
            </html>
        );
    }
}

export default Full;
