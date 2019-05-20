import React, {Component} from 'react';
import Nav from '../../components/Nav/';
import Body from '../../components/Body/';
import './Full.css'

class Full extends Component {
    
    componentDidMount() {
        this.render();
    };

    render() {
        return (         
            <div className="app">
                <Nav />
                <Body />
            </div>
        );
    }
}

export default Full;
