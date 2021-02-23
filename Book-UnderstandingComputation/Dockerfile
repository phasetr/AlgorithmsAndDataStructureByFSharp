FROM jupyter/datascience-notebook
USER root

RUN apt-get update && \
    apt-get -y install jupyter-notebook ruby ruby-ffi-rzmq && \
    gem install iruby && \
    iruby register --force && \
    pip install jupytext

# RUN julia -e 'using Pkg; Pkg.add("Plots"); using Plots' && \
#     julia -e 'using Pkg; Pkg.add("DifferentialEquations"); using DifferentialEquations'

RUN mkdir -p /home/jovyan/.jupyter/lab/user-settings/@jupyterlab/apputils-extension && \
    jupconfig="/home/jovyan/.jupyter/jupyter_notebook_config.py" && \
    echo '{"theme":"JupyterLab Dark"}' > \
      /home/jovyan/.jupyter/lab/user-settings/@jupyterlab/apputils-extension/themes.jupyterlab-settings && \
    echo 'c.NotebookApp.contents_manager_class = "jupytext.TextFileContentsManager"' >> ${jupconfig} && \
    echo 'c.ContentsManager.default_jupytext_formats = "ipynb,md"' >> ${jupconfig}

ENV LANG ja_JP.UTF-8
ENV LANGUAGE ja_JP:ja
ENV LC_ALL ja_JP.UTF-8
ENV TZ JST-9

#CMD ["jupyter-notebook", "--port=8000", "--ip=0.0.0.0", "--allow-root", "--NotebookApp.token=''"]
