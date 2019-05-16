import React, {Component} from 'react';

class Nav extends Component {

  render() {
    return (
        <div class="nav">
        <ul>
            <li class="home"><a class="active" href="#">Home</a></li>
            <li class="tutorials"><a href="#">Tutorials</a></li>
            <li class="about"><a href="#">About</a></li>
            <li class="news"><a href="#">Newsletter</a></li>
            <li class="contact"><a href="#">Contact</a></li>
        </ul>
        </div>        
    );
  }
}
 

export default Nav;