# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'py_test.ui'
#
# Created by: PyQt5 UI code generator 5.15.6
#
# WARNING: Any manual changes made to this file will be lost when pyuic5 is
# run again.  Do not edit this file unless you know what you are doing.


from PyQt5 import QtCore, QtGui, QtWidgets


class Ui_pyTest(object):
    def setupUi(self, pyTest):
        pyTest.setObjectName("pyTest")
        pyTest.resize(1289, 605)
        self.gridLayout_6 = QtWidgets.QGridLayout(pyTest)
        self.gridLayout_6.setObjectName("gridLayout_6")
        self.groupBox = QtWidgets.QGroupBox(pyTest)
        self.groupBox.setObjectName("groupBox")
        self.gridLayout_2 = QtWidgets.QGridLayout(self.groupBox)
        self.gridLayout_2.setObjectName("gridLayout_2")
        self.gridLayout = QtWidgets.QGridLayout()
        self.gridLayout.setObjectName("gridLayout")
        self.label = QtWidgets.QLabel(self.groupBox)
        font = QtGui.QFont()
        font.setFamily("Arial")
        font.setPointSize(11)
        self.label.setFont(font)
        self.label.setAlignment(QtCore.Qt.AlignCenter)
        self.label.setObjectName("label")
        self.gridLayout.addWidget(self.label, 0, 0, 1, 1)
        self.ip = QtWidgets.QLabel(self.groupBox)
        font = QtGui.QFont()
        font.setFamily("Arial")
        font.setPointSize(11)
        self.ip.setFont(font)
        self.ip.setStyleSheet("background-color: rgba(255, 0, 0, 100);")
        self.ip.setFrameShape(QtWidgets.QFrame.Panel)
        self.ip.setText("")
        self.ip.setAlignment(QtCore.Qt.AlignCenter)
        self.ip.setObjectName("ip")
        self.gridLayout.addWidget(self.ip, 0, 1, 1, 1)
        self.label_4 = QtWidgets.QLabel(self.groupBox)
        font = QtGui.QFont()
        font.setFamily("Arial")
        font.setPointSize(11)
        self.label_4.setFont(font)
        self.label_4.setAlignment(QtCore.Qt.AlignCenter)
        self.label_4.setObjectName("label_4")
        self.gridLayout.addWidget(self.label_4, 0, 2, 1, 1)
        self.port = QtWidgets.QLabel(self.groupBox)
        font = QtGui.QFont()
        font.setFamily("Arial")
        font.setPointSize(11)
        self.port.setFont(font)
        self.port.setStyleSheet("background-color: rgba(255, 0, 0, 100);")
        self.port.setFrameShape(QtWidgets.QFrame.Panel)
        self.port.setText("")
        self.port.setAlignment(QtCore.Qt.AlignCenter)
        self.port.setObjectName("port")
        self.gridLayout.addWidget(self.port, 0, 3, 1, 1)
        self.RecDataShowCheck = QtWidgets.QCheckBox(self.groupBox)
        self.RecDataShowCheck.setChecked(False)
        self.RecDataShowCheck.setObjectName("RecDataShowCheck")
        self.gridLayout.addWidget(self.RecDataShowCheck, 0, 4, 1, 1)
        self.RecDataBrowser = QtWidgets.QTextBrowser(self.groupBox)
        self.RecDataBrowser.setMinimumSize(QtCore.QSize(705, 221))
        self.RecDataBrowser.setStyleSheet("")
        self.RecDataBrowser.setObjectName("RecDataBrowser")
        self.gridLayout.addWidget(self.RecDataBrowser, 1, 0, 1, 5)
        self.gridLayout_2.addLayout(self.gridLayout, 0, 0, 1, 1)
        self.imageShowLabel = QtWidgets.QLabel(self.groupBox)
        self.imageShowLabel.setMinimumSize(QtCore.QSize(256, 256))
        self.imageShowLabel.setFrameShape(QtWidgets.QFrame.Panel)
        self.imageShowLabel.setText("")
        self.imageShowLabel.setObjectName("imageShowLabel")
        self.gridLayout_2.addWidget(self.imageShowLabel, 0, 1, 1, 1)
        self.gridLayout_6.addWidget(self.groupBox, 0, 0, 1, 1)
        self.groupBox_3 = QtWidgets.QGroupBox(pyTest)
        self.groupBox_3.setObjectName("groupBox_3")
        self.gridLayout_4 = QtWidgets.QGridLayout(self.groupBox_3)
        self.gridLayout_4.setObjectName("gridLayout_4")
        self.RoadOpencv = QtWidgets.QLabel(self.groupBox_3)
        self.RoadOpencv.setMinimumSize(QtCore.QSize(256, 256))
        self.RoadOpencv.setMaximumSize(QtCore.QSize(256, 275))
        self.RoadOpencv.setFrameShape(QtWidgets.QFrame.Panel)
        self.RoadOpencv.setText("")
        self.RoadOpencv.setObjectName("RoadOpencv")
        self.gridLayout_4.addWidget(self.RoadOpencv, 0, 0, 1, 1)
        self.gridLayout_6.addWidget(self.groupBox_3, 0, 1, 1, 1)
        self.groupBox_2 = QtWidgets.QGroupBox(pyTest)
        self.groupBox_2.setObjectName("groupBox_2")
        self.gridLayout_3 = QtWidgets.QGridLayout(self.groupBox_2)
        self.gridLayout_3.setObjectName("gridLayout_3")
        self.label_3 = QtWidgets.QLabel(self.groupBox_2)
        self.label_3.setObjectName("label_3")
        self.gridLayout_3.addWidget(self.label_3, 1, 0, 1, 1)
        self.NaviDataSendShow = QtWidgets.QTextBrowser(self.groupBox_2)
        self.NaviDataSendShow.setStyleSheet("")
        self.NaviDataSendShow.setObjectName("NaviDataSendShow")
        self.gridLayout_3.addWidget(self.NaviDataSendShow, 4, 0, 1, 1)
        self.horizontalLayout = QtWidgets.QHBoxLayout()
        self.horizontalLayout.setObjectName("horizontalLayout")
        self.label_2 = QtWidgets.QLabel(self.groupBox_2)
        font = QtGui.QFont()
        font.setFamily("Arial")
        font.setPointSize(11)
        self.label_2.setFont(font)
        self.label_2.setAlignment(QtCore.Qt.AlignCenter)
        self.label_2.setObjectName("label_2")
        self.horizontalLayout.addWidget(self.label_2)
        self.NaviIp = QtWidgets.QLabel(self.groupBox_2)
        font = QtGui.QFont()
        font.setFamily("Arial")
        font.setPointSize(11)
        self.NaviIp.setFont(font)
        self.NaviIp.setStyleSheet("background-color: rgba(255, 0, 0, 100);")
        self.NaviIp.setFrameShape(QtWidgets.QFrame.Panel)
        self.NaviIp.setText("")
        self.NaviIp.setAlignment(QtCore.Qt.AlignCenter)
        self.NaviIp.setObjectName("NaviIp")
        self.horizontalLayout.addWidget(self.NaviIp)
        self.label_5 = QtWidgets.QLabel(self.groupBox_2)
        font = QtGui.QFont()
        font.setFamily("Arial")
        font.setPointSize(11)
        self.label_5.setFont(font)
        self.label_5.setAlignment(QtCore.Qt.AlignCenter)
        self.label_5.setObjectName("label_5")
        self.horizontalLayout.addWidget(self.label_5)
        self.NaviPort = QtWidgets.QLabel(self.groupBox_2)
        font = QtGui.QFont()
        font.setFamily("Arial")
        font.setPointSize(11)
        self.NaviPort.setFont(font)
        self.NaviPort.setStyleSheet("background-color: rgba(255, 0, 0, 100);")
        self.NaviPort.setFrameShape(QtWidgets.QFrame.Panel)
        self.NaviPort.setText("")
        self.NaviPort.setAlignment(QtCore.Qt.AlignCenter)
        self.NaviPort.setObjectName("NaviPort")
        self.horizontalLayout.addWidget(self.NaviPort)
        self.NaviRecDataShowCheck = QtWidgets.QCheckBox(self.groupBox_2)
        self.NaviRecDataShowCheck.setChecked(False)
        self.NaviRecDataShowCheck.setObjectName("NaviRecDataShowCheck")
        self.horizontalLayout.addWidget(self.NaviRecDataShowCheck)
        self.gridLayout_3.addLayout(self.horizontalLayout, 0, 0, 1, 1)
        self.NaviDataRecShow = QtWidgets.QTextBrowser(self.groupBox_2)
        self.NaviDataRecShow.setStyleSheet("")
        self.NaviDataRecShow.setObjectName("NaviDataRecShow")
        self.gridLayout_3.addWidget(self.NaviDataRecShow, 2, 0, 1, 1)
        self.label_6 = QtWidgets.QLabel(self.groupBox_2)
        self.label_6.setObjectName("label_6")
        self.gridLayout_3.addWidget(self.label_6, 3, 0, 1, 1)
        self.gridLayout_6.addWidget(self.groupBox_2, 1, 0, 1, 1)
        self.groupBox_4 = QtWidgets.QGroupBox(pyTest)
        self.groupBox_4.setObjectName("groupBox_4")
        self.gridLayout_5 = QtWidgets.QGridLayout(self.groupBox_4)
        self.gridLayout_5.setObjectName("gridLayout_5")
        self.RoadDeeplab = QtWidgets.QLabel(self.groupBox_4)
        self.RoadDeeplab.setMinimumSize(QtCore.QSize(256, 256))
        self.RoadDeeplab.setMaximumSize(QtCore.QSize(256, 275))
        self.RoadDeeplab.setFrameShape(QtWidgets.QFrame.Panel)
        self.RoadDeeplab.setText("")
        self.RoadDeeplab.setObjectName("RoadDeeplab")
        self.gridLayout_5.addWidget(self.RoadDeeplab, 0, 0, 1, 1)
        self.gridLayout_6.addWidget(self.groupBox_4, 1, 1, 1, 1)
        self.groupBox_2.raise_()
        self.groupBox.raise_()
        self.groupBox_3.raise_()
        self.groupBox_4.raise_()

        self.retranslateUi(pyTest)
        QtCore.QMetaObject.connectSlotsByName(pyTest)

    def retranslateUi(self, pyTest):
        _translate = QtCore.QCoreApplication.translate
        pyTest.setWindowTitle(_translate("pyTest", "Main Window"))
        self.groupBox.setTitle(_translate("pyTest", "Tcp Sever Test"))
        self.label.setText(_translate("pyTest", "ip:"))
        self.label_4.setText(_translate("pyTest", "port:"))
        self.RecDataShowCheck.setText(_translate("pyTest", "Receive Data Show"))
        self.RecDataBrowser.setHtml(_translate("pyTest", "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0//EN\" \"http://www.w3.org/TR/REC-html40/strict.dtd\">\n"
"<html><head><meta name=\"qrichtext\" content=\"1\" /><style type=\"text/css\">\n"
"p, li { white-space: pre-wrap; }\n"
"</style></head><body style=\" font-family:\'SimSun\'; font-size:9pt; font-weight:400; font-style:normal;\">\n"
"<p style=\" margin-top:0px; margin-bottom:0px; margin-left:0px; margin-right:0px; -qt-block-indent:0; text-indent:0px;\">TCP Receive data:</p></body></html>"))
        self.groupBox_3.setTitle(_translate("pyTest", "opencv"))
        self.groupBox_2.setTitle(_translate("pyTest", "Navigation connect test"))
        self.label_3.setText(_translate("pyTest", "receive"))
        self.NaviDataSendShow.setHtml(_translate("pyTest", "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0//EN\" \"http://www.w3.org/TR/REC-html40/strict.dtd\">\n"
"<html><head><meta name=\"qrichtext\" content=\"1\" /><style type=\"text/css\">\n"
"p, li { white-space: pre-wrap; }\n"
"</style></head><body style=\" font-family:\'SimSun\'; font-size:9pt; font-weight:400; font-style:normal;\">\n"
"<p style=\" margin-top:0px; margin-bottom:0px; margin-left:0px; margin-right:0px; -qt-block-indent:0; text-indent:0px;\">Send data:</p></body></html>"))
        self.label_2.setText(_translate("pyTest", "Navigation ip:"))
        self.label_5.setText(_translate("pyTest", "Navigation port:"))
        self.NaviRecDataShowCheck.setText(_translate("pyTest", "Receive Data Show"))
        self.NaviDataRecShow.setHtml(_translate("pyTest", "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0//EN\" \"http://www.w3.org/TR/REC-html40/strict.dtd\">\n"
"<html><head><meta name=\"qrichtext\" content=\"1\" /><style type=\"text/css\">\n"
"p, li { white-space: pre-wrap; }\n"
"</style></head><body style=\" font-family:\'SimSun\'; font-size:9pt; font-weight:400; font-style:normal;\">\n"
"<p style=\" margin-top:0px; margin-bottom:0px; margin-left:0px; margin-right:0px; -qt-block-indent:0; text-indent:0px;\">Receive data:</p></body></html>"))
        self.label_6.setText(_translate("pyTest", "send"))
        self.groupBox_4.setTitle(_translate("pyTest", "Deeplabv3+"))
