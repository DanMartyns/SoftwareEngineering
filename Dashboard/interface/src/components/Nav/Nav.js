import React, {Component} from 'react';
import "./Nav.css"

class Nav extends Component {

  render() {
    return (
      <div class="nav">
        <ul>
            <li class="home"><a class="active" href="/">Home</a></li>
            <li class="documentation"><a href="/">Documentation</a></li>
            <li class="about"><a href="/">About</a></li>
        </ul>
      </div>      
    );
  }
}
 

export default Nav;