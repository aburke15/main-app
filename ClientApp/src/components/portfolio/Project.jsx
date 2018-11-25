import React, { Component } from 'react';
import { Grid, Row } from 'react-bootstrap';


export class Project extends Component {

    render() {
        return (
            <section id="projects" className="projects-section global-padding">
                <Grid>
                    <Row>
                        <h2 className="text-center">Projects</h2>
                        <p className="b-underline"></p>
                    </Row>
                </Grid>
            </section>
        );
    }
}