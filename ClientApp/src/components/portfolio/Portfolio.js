import React, { Component } from 'react';
import { Grid, Col, Row } from 'react-bootstrap';
import './Portfolio.css';

export class Portfolio extends Component {
    displayName = Portfolio.name;
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="portfolio-font">
                <Title />
            </div>
        );
    }
}

class Title extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <Grid className="title-section parallax">
                <Grid bsClass="container">
                    <h1 className="text-center title title-color">Andre Burke</h1>
                    <h2 className="text-center sub-title title-color">Software Engineer</h2>
                </Grid>
            </Grid>
        );
    }
}

class Bio extends Component {
    constructor(props) {
        super(props);
    }
}

class Skill extends Component {
    constructor(props) {
        super(props);
    }
}

class Resume extends Component {
    constructor(props) {
        super(props);
    }
}

class Project extends Component {
    constructor(props) {
        super(props);
    }
}

class Contact extends Component {
    constructor(props) {
        super(props);
    }
}