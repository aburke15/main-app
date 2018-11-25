import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={'#title'}>Andre Burke</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <LinkContainer to={'#me'}>
              <NavItem>
                <Glyphicon glyph='user' /> Me
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'#skills'}>
              <NavItem>
                <Glyphicon glyph='tasks' /> Skills
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'#resume'}>
              <NavItem>
                <Glyphicon glyph='list-alt' /> Resume
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'#projects'}>
              <NavItem>
                <Glyphicon glyph='list' /> Projects
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'#contact'}>
              <NavItem>
                <Glyphicon glyph='earphone' /> Contact
              </NavItem>
            </LinkContainer>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
