import React, {Component} from 'react';
import './DisplayResultDT.css'
import { Services } from 'grommet-icons';

class DisplayResultDT extends Component {

    constructor(props){
        super(props);
    }

    render() {
    return (
        <div className="result">
            <Services color='plain' size='large' /> 
            <h2>{this.props.title}</h2>
            <p>{this.props.result}</p>
        </div>
    );
    }
    }

export default DisplayResultDT;