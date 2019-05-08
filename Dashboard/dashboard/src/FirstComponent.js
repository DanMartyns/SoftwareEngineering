import React, {Component} from 'react';

class FirstComponent extends Component {
    /**
     * The props attribute in the constructor will contain 
     * all the parameters which are passed as input to this component.
     * @param props 
     */
    constructor(props) {
        super(props)
    }
    render() {
        const element = (<div>Text from Element</div>)
        return (
            <div className="comptext">
            <h3>First Component</h3>
            {this.props.displaytext}
            {element}
            </div>)
    }
}

export default FirstComponent;