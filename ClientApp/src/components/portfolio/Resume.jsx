import React, { Component } from 'react'; 
import { Grid, Row } from 'react-bootstrap';

export class Resume extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <section className="resume-section global-padding">
                <Grid>
                    <Row>
                        <h2 className="text-center">Resume</h2>
                        <p className="b-underline"></p>
                    </Row>
                    <Row className="global-margin">
                        <img className="img-responsive" src="../img/portfolio/Andre Burke.jpg" alt="My Resume" />
                    </Row>
                </Grid>
            </section>
        );
    }
}