import React, { Component } from 'react';
import { Glyphicon, Grid, Row, Col } from 'react-bootstrap';

export class Contact extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <section className="contact-section global-padding">
                <Grid>
                    <Row className="contact-margin">
                        <h4 className="text-center">
                            <a className="contact-email" href="mailto:aburkex24@gmail.com" target="_top">
                                <Glyphicon glyph="envelope" /> aburkex24@gmail.com
                            </a>
                        </h4>
                        <h4 className="text-center contact-phone">
                            <Glyphicon glyph="phone" /> 801-708-2782
                        </h4>
                    </Row>
                    <Row>
                        <Col md={4}>
                            <a href="https://www.linkedin.com/in/aburkex24" target="_blank">
                                <img className="contact-icon" src="../img/portfolio/linkedin.png" />
                            </a>
                        </Col>
                        <Col md={4}>
                            <a href="https://www.youtube.com/channel/UCczcmJfcsvhmW-65r1RuZ4w/featured?view_as=subscriber" target="_blank">
                                <img className="contact-icon" src="../img/portfolio/youtube.png" />
                            </a>
                        </Col>
                        <Col md={4}>
                            <a href="https://github.com/aburkex24" target="_blank">
                                <img className="contact-icon" src="../img/portfolio/github.png" />
                            </a>
                        </Col>
                    </Row>
                </Grid>
            </section>
        );
    }
}