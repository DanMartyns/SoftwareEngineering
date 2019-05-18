import React, {Component} from 'react';
import './DisplayResultHR.css'
import { Aed } from 'grommet-icons';

class DisplayResultHR extends Component {

    constructor(props){
        super(props);
    }

    render() {
    return (
        <div className="result">
            <Aed color='plain' size='large' /> 
            <h2>{this.props.title}</h2>
            <p>{this.props.result}</p>
        </div>
    );
    }
    }

export default DisplayResultHR;