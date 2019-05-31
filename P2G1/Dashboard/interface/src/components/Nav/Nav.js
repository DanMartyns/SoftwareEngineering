import React, {Component} from 'react';
import "./Nav.css"

class Nav extends Component {

  render() {
    return (
      <div className="nav">
        <ul>
            <li className="home"><a className="active" href="/">Home</a></li>
            <li className="documentation"><a href="/">Documentation</a></li>
            <li className="about"><a href="/">About</a></li>
        </ul>
      </div>      
    );
  }
}
 

export default Nav;